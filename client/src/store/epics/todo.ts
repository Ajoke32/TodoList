import {Epic, ofType} from "redux-observable";
import {Todo, TodoAction, TodoActionTypes,} from "../../types/todo";
import {catchError, filter, from, map, mergeMap, of} from "rxjs";
import {ajax} from "rxjs/internal/ajax/ajax";
import {fetchTodoSuccess, removeTodoSuccess, updateTodoFail, updateTodoSuccess} from "../action-creators/todo";
import {todoClient} from "../../apollo";
import {action, isOfType} from "typesafe-actions";
import {removeTaskMutation, updateTaskMutation} from "../../graphQL/mutations/todo";


interface TaskResponse {
    data: {
        tasks: []
    }
}
interface UpdateTaskResponse {
    updateTask:Todo
}
interface UpdateVars{
    task:Todo,
}

function fetchTodo() {
    return ajax<TaskResponse>({
        method: 'POST',
        url: "http://localhost:5266/tasks",
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({query})
    });
}

const query = 'query{tasks{id,title,expirationDate,isCompleted,categoryId}}'


export const fetchTodosEpic: Epic<TodoAction> = (action$) => action$.pipe(
    ofType(TodoActionTypes.FETCH_TODOS),
    mergeMap(action =>
        fetchTodo()
            .pipe(
                map(response => {
                    return fetchTodoSuccess(response.response.data.tasks)
                })
            ))
);


export const updateTodoEpic:Epic<TodoAction> = (action$)=>action$.pipe(
    filter(isOfType(TodoActionTypes.UPDATE_TODO)),
    mergeMap(action=> {
        return from(
           todoClient.mutate<UpdateTaskResponse,UpdateVars>(
               {
                   mutation:updateTaskMutation,
                   variables:{
                       task:action.payload,
                   }
               }
           )
        ).pipe(
            map(res=> {
                if(res.data){
                    return updateTodoSuccess(res.data.updateTask);
                }
                return updateTodoFail("data fetching fail");
            }),
            catchError(() => of(updateTodoFail("updating fail")))
        )
    }
    )
);

export const deleteTodoEpic:Epic<TodoAction> = ($action)=>$action.pipe(
    filter(isOfType(TodoActionTypes.DELETE_TODO)),
    mergeMap(action=>{
        return from(todoClient.mutate(
            {
                mutation:removeTaskMutation,
                variables:{id:action.payload}
            }
        )).pipe(
            map(res=>removeTodoSuccess(action.payload))
        )
    })
)


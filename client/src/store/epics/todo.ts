import {Epic, ofType} from "redux-observable";
import {Todo, TodoAction, TodoActionTypes,} from "../../types/todo";
import {catchError, filter, from, map, mergeMap, of} from "rxjs";
import {
    createTodoSuccess, creatTodoFail,
    fetchTodoSuccess,
    removeTodoSuccess,
    updateTodoFail,
    updateTodoSuccess
} from "../action-creators/todo";
import {todoClient} from "../../apollo";
import {isOfType} from "typesafe-actions";
import {createTaskMutations, removeTaskMutation, updateTaskMutation} from "../../graphQL/mutations/todo";
import moment from "moment";
import {getAllTaskQuery} from "../../graphQL/query/todo";
import omitDeep from "omit-deep-lodash";


interface TaskResponse {
    todo: {
        tasks:Todo[]
    }
}
interface UpdateTaskResponse {
    todo:{
        updateTask:Todo
    }
}
interface CreateTaskResponse{
    todo:{
        createTask:Todo
    }
}
interface UpdateVars{
    task:Todo,
}

export const fetchTodosEpic: Epic<TodoAction> = (action$) => action$.pipe(
    ofType(TodoActionTypes.FETCH_TODOS),
    mergeMap(action =>
         from(
            todoClient.query<TaskResponse>(
                {
                    query:getAllTaskQuery
                }
            )).pipe(
            map(response => {
                const res = omitDeep(response.data.todo.tasks,'__typename') as Todo[];
                return fetchTodoSuccess(res);
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
                    return updateTodoSuccess(res.data.todo.updateTask);
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
);

export const createTodoEpic:Epic<TodoAction> = ($action)=>$action.pipe(
  filter(isOfType(TodoActionTypes.CREATE_TODO)),
  mergeMap(action=>{
      return from(todoClient.mutate<CreateTaskResponse>(
          {
              mutation:createTaskMutations,
              variables:{
                  task:{
                      title:action.payload.title,
                      expirationDate:action.payload.expirationDate!==null?moment(action.payload.expirationDate).format():null,
                      categoryId:action.payload.categoryId
                  }
              }
          }
      )).pipe(
          map(res=>{
              if(res.data){
                  return createTodoSuccess(res.data.todo.createTask)
              }
              return creatTodoFail("data empty");
          })
      );
  })
);


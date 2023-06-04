
import {Todo, TodoAction, TodoActionTypes} from "../../types/todo";





export const removeTodo = (id:number):TodoAction=>({
        type:TodoActionTypes.DELETE_TODO,
        payload:id
});

export const removeTodoSuccess = (id:number):TodoAction => ({
    type:TodoActionTypes.DELETE_TODO_SUCCESS,
    payload:id
});


//fetch
export const fetchTodo = ():TodoAction=>(
    {
        type:TodoActionTypes.FETCH_TODOS,
        payload:"Fetching"
    }
);

export const fetchTodoSuccess = (todos:Todo[]):TodoAction =>({
    type:TodoActionTypes.FETCH_TODOS_SUCCESS,
    payload:todos
});
//fetch



// update
export const updateTodoSuccess = (todo:Todo):TodoAction =>({
    type:TodoActionTypes.UPDATE_TODO_SUCCESS,
    payload:todo
});

export const updateTodoFail = (msg:string):TodoAction=>({
    type:TodoActionTypes.UPDATE_TODO_FAIL,
    payload:msg
});

export const updateTodo = (todo:Todo):TodoAction =>({
    type:TodoActionTypes.UPDATE_TODO,
    payload:todo
});
// update
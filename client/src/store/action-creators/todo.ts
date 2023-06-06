import {Todo, TodoAction, TodoActionTypes} from "../../types/todo";


// remove
export const removeTodo = (id:number):TodoAction=>({
        type:TodoActionTypes.DELETE_TODO,
        payload:id
});

export const removeTodoSuccess = (id:number):TodoAction => ({
    type:TodoActionTypes.DELETE_TODO_SUCCESS,
    payload:id
});
//remove


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

//create
export const createTodo = (todo:Todo):TodoAction=>({
   type:TodoActionTypes.CREATE_TODO,
   payload:todo
});

export const createTodoSuccess = (todo:Todo):TodoAction=>({
    type:TodoActionTypes.CREATE_TODO_SUCCESS,
    payload:todo
});

export const creatTodoFail = (msg:string):TodoAction => ({
   type:TodoActionTypes.CREATE_TODO_FAIL,
   payload:msg
});
//create
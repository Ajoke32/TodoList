import {Dispatch} from "react";
import {Todo, TodoAction, TodoActionTypes} from "../../types/todo";


export const createTodo = (todo:Todo)=>{
     return (dispatch:Dispatch<TodoAction>)=>{
         try {
             dispatch({type:TodoActionTypes.CREATE_TODO,payload:todo})
         }catch (e){
             console.log(e);
         }
     }
}

export const removeTodo = (id:number)=>{
    return (dispatch:Dispatch<TodoAction>)=>{
        try {
            dispatch({type:TodoActionTypes.DELETE_TODO,payload:id})
        }catch (e){
            console.log(e);
        }
    }
}

export const getTodoById = (id:number)=>{
    return (dispatch:Dispatch<TodoAction>)=>{
        try {
            dispatch({type:TodoActionTypes.GET_TODO_BY_ID,payload:id})
        }catch (e){
            console.log(e);
        }
    }
}

export const updateTodo = (todo:Todo) =>{
    return (dispatch:Dispatch<TodoAction>)=>{
        try {
            dispatch({type:TodoActionTypes.UPDATE_TODO,payload:todo})
        }catch (e){
            console.log(e);
        }
    }
}
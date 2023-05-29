import {TodoAction, TodoActionTypes, TodoState} from "../../types/todo";


const initialState:TodoState = {
    todos:[]
}

export const todoReducer = (state:TodoState=initialState,action:TodoAction):TodoState=>{
   switch (action.type){
       case TodoActionTypes.CREATE_TODO:{
           return {...state,todos:[...state.todos,action.payload]}
       }
       case TodoActionTypes.UPDATE_TODO:{
           state.todos.map(t=>{
               if(t.id===action.payload.id){
                   t = action.payload
               }
               return t;
           });
           return {...state,todos:[...state.todos]}
       }
       case TodoActionTypes.DELETE_TODO:{
           return {...state,todos:state.todos.filter(t=>{
                  return t.id!==action.payload
               })}
       }
       case TodoActionTypes.GET_TODO_BY_ID:{
           return {...state,todos:state.todos.filter(t=>t.id===action.payload)}
       }
       default: return state;
   }
}
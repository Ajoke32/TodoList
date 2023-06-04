import {TodoAction, TodoActionTypes, TodoState} from "../../types/todo";


const initialState:TodoState = {
    todos:[],
    loading:true,
    error:false
}

export const todoReducer = (state:TodoState=initialState,action:TodoAction):TodoState=>{
   switch (action.type){
       case TodoActionTypes.DELETE_TODO_SUCCESS:{
           return {...state,todos:state.todos.filter(t=>{
                  return t.id!==action.payload
               })}
       }

       case TodoActionTypes.GET_TODO_BY_ID:{
           return {...state,todos:state.todos.filter(t=>t.id===action.payload)}
       }
       case TodoActionTypes.FETCH_TODOS:{
           return {...state,loading:true}
       }
       case TodoActionTypes.FETCH_TODOS_SUCCESS:{
           return {...state,todos:action.payload,loading:false}
       }



       case TodoActionTypes.UPDATE_TODO_FAIL:{
           return {...state,loading:false,error:true}
       }
       case TodoActionTypes.UPDATE_TODO_SUCCESS:{
           const index = state.todos.findIndex(t=>t.id===action.payload.id);
           state.todos[index]=action.payload;
           return {...state,todos:[...state.todos]}
       }

       default: return state;
   }
}
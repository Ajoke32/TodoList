


export interface Todo{
    id:number
    title:string,
    categoryName:string,
    isCompleted:boolean,
    expirationDate?:Date|null
}

export interface TodoState{
    todos:Todo[],
    loading:boolean,
    error:boolean
}

export enum TodoActionTypes{
    CREATE_TODO="CREATE_TODO",

    DELETE_TODO="DELETE_TODO",
    DELETE_TODO_SUCCESS = "DELETE_TODO_SUCCESS",

    GET_TODO_BY_ID = "GET_TODO_BY_ID",
    FETCH_TODOS_SUCCESS = "FETCH_TODOS_SUCCESS",
    CREATE_TODO_SUCCESS = "CREATE_TODO_SUCCESS",
    FETCH_TODOS = "FETCH_TODOS",

    UPDATE_TODO="UPDATE_TODO",
    UPDATE_TODO_SUCCESS = "UPDATE_TODO_SUCCESS",
    UPDATE_TODO_FAIL = "UPDATE_TODO_FAIL"
}



interface ActionWithPayload<T,Tp>{
    type:T,
    payload:Tp
}
interface CreateTodoAction{
   type:TodoActionTypes.CREATE_TODO,
   payload:Todo
}




interface FetchTodos{
    type:TodoActionTypes.FETCH_TODOS,
    payload:string
}
interface GetTodoById{
    type:TodoActionTypes.GET_TODO_BY_ID,
    payload:number
}

interface CreateTodoSuccess{
    type:TodoActionTypes.CREATE_TODO_SUCCESS,
    payload:string
}
interface FetchTodosSuccess{
    type:TodoActionTypes.FETCH_TODOS_SUCCESS,
    payload:Todo[]
}

interface UpdateTodoSuccess{
    type:TodoActionTypes.UPDATE_TODO_SUCCESS,
    payload:Todo
}

interface UpdateTodoFail {
    type:TodoActionTypes.UPDATE_TODO_FAIL,
    payload:string
}


export type TodoAction = ActionWithPayload<TodoActionTypes.CREATE_TODO_SUCCESS,string>|UpdateTodoFail|
   ActionWithPayload<TodoActionTypes.DELETE_TODO, number>|GetTodoById|
    FetchTodosSuccess|CreateTodoSuccess|ActionWithPayload<TodoActionTypes.UPDATE_TODO, Todo>|UpdateTodoSuccess|
    ActionWithPayload<TodoActionTypes.DELETE_TODO_SUCCESS,number>|FetchTodos


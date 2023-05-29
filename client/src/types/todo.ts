

export interface Todo{
    id:number
    title:string,
    categoryName:string,
    isCompleted:boolean,
    expirationDate?:Date|null
}

export interface TodoState{
    todos:Todo[]
}

export enum TodoActionTypes{
    CREATE_TODO="CREATE_TODO",
    UPDATE_TODO="UPDATE_TODO",
    DELETE_TODO="DELETE_TODO",
    GET_TODO_BY_ID = "GET_TODO_BY_ID"
}

interface CreateTodoAction{
   type:TodoActionTypes.CREATE_TODO,
   payload:Todo
}
interface UpdateTodoAction{
    type:TodoActionTypes.UPDATE_TODO,
    payload:Todo
}
interface DeleteTodoAction{
    type:TodoActionTypes.DELETE_TODO,
    payload:number
}

interface GetTodoById{
    type:TodoActionTypes.GET_TODO_BY_ID,
    payload:number
}


export type TodoAction = CreateTodoAction|UpdateTodoAction|DeleteTodoAction|GetTodoById


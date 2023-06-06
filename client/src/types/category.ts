import {ActionWithPayload} from "./todo";

export interface Category{
    id:number,
    title:string
}

export interface CategoryState{
    categories:Category[],
    error:string,
    isLoaded:boolean
}

export enum CategoryActionTypes{
    FETCH_CATEGORIES = "FETCH_CATEGORIES",
    FETCH_CATEGORIES_SUCCESS = "FETCH_CATEGORIES_SUCCESS",
    FETCH_CATEGORIES_FAIL = "FETCH_CATEGORIES_FAIL",

    CREATE_CATEGORY = "CREATE_CATEGORY",
    CREATE_CATEGORY_SUCCESS = "CREATE_CATEGORY_SUCCESS",
    CREATE_CATEGORY_FAIL = "CREATE_CATEGORY_FAIL",
}

interface CreateCategoryAction{
    type:CategoryActionTypes.CREATE_CATEGORY,
    payload:string
}



interface ActionWithoutPayload<T>{
    type:T
}

export type CategoryAction =|CreateCategoryAction|ActionWithoutPayload<CategoryActionTypes.FETCH_CATEGORIES>|
    ActionWithPayload<CategoryActionTypes.FETCH_CATEGORIES_SUCCESS,Category[]>|
    ActionWithPayload<CategoryActionTypes.FETCH_CATEGORIES_FAIL, string>|
    ActionWithPayload<CategoryActionTypes.CREATE_CATEGORY_SUCCESS, Category>|
    ActionWithPayload<CategoryActionTypes.CREATE_CATEGORY_FAIL,string>;
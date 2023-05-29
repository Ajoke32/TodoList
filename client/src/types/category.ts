
export interface Category{
    id:number,
    name:string
}

export interface CategoryState{
    categories:Category[],
}

export enum CategoryActionTypes{
    CREATE_CATEGORY="CREATE_CATEGORY",
    UPDATE_CATEGORY="UPDATE_CATEGORY",
    DELETE_CATEGORY="DELETE_CATEGORY",
    GET_CATEGORY_BY_NAME="GET_CATEGORY_BY_NAME",
}

interface CreateCategoryAction{
    type:CategoryActionTypes.CREATE_CATEGORY,
    payload:Category
}

interface GetCategoryByName{
    type:CategoryActionTypes.GET_CATEGORY_BY_NAME,
    payload:Category|null
}

interface DeleteCategoryAction{
    type:CategoryActionTypes.DELETE_CATEGORY,
    payload:number
}
interface UpdateCategoryAction{
    type:CategoryActionTypes.UPDATE_CATEGORY,
    payload:Category
}

export type CategoryAction = DeleteCategoryAction|CreateCategoryAction|UpdateCategoryAction|GetCategoryByName;
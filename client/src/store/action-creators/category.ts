import {Category, CategoryAction, CategoryActionTypes} from "../../types/category";


//create
export const createCategorySuccess = (category:Category):CategoryAction=>({
    type:CategoryActionTypes.CREATE_CATEGORY_SUCCESS,
    payload:category
});

export const createCategory = (title:string):CategoryAction=>({
    type:CategoryActionTypes.CREATE_CATEGORY,
    payload:title
});


export const createCategoryFail = (msg:string):CategoryAction=>({
   type:CategoryActionTypes.CREATE_CATEGORY_FAIL,
    payload:msg
});
//create


//fetch
export const fetchCategory = ():CategoryAction =>({
   type:CategoryActionTypes.FETCH_CATEGORIES
});

export const fetchCategorySuccess = (categories:Category[]):CategoryAction =>({
    type:CategoryActionTypes.FETCH_CATEGORIES_SUCCESS,
    payload:categories
});

export const fetchCategoryFail = (message:string):CategoryAction =>({
    type:CategoryActionTypes.FETCH_CATEGORIES_FAIL,
    payload:message
});
//fetch

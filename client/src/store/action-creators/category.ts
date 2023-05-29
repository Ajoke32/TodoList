import {Category, CategoryAction, CategoryActionTypes} from "../../types/category";
import {Dispatch} from "react";



export const createCategory = (category:Category)=>{
    return (dispatch:Dispatch<CategoryAction>) =>{
        try{
            dispatch({type:CategoryActionTypes.CREATE_CATEGORY,payload:category})
        }catch (e){
            console.log(e)
        }
    }
}


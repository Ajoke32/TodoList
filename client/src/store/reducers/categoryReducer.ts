import {CategoryAction, CategoryActionTypes, CategoryState} from "../../types/category";


const initialState:CategoryState = {
    categories:[
        {id:1,name:"Sport"}
    ],
}

export const categoryReducer = (categoryState:CategoryState=initialState,action:CategoryAction)=>{
    switch (action.type){
        case CategoryActionTypes.CREATE_CATEGORY:{
            return {...categoryState,categories:[...categoryState.categories,action.payload]}
        }
        default:return categoryState;
    }
}
import {CategoryAction, CategoryActionTypes, CategoryState} from "../../types/category";


const initialState:CategoryState = {
    categories:[],
    error:"",
    isLoaded:false
}

export const categoryReducer = (categoryState:CategoryState=initialState,action:CategoryAction)=>{
    switch (action.type){
        case CategoryActionTypes.CREATE_CATEGORY:{
            return {...categoryState,isLoaded:false}
        }
        case CategoryActionTypes.CREATE_CATEGORY_SUCCESS:{
            return {...categoryState,categories:[...categoryState.categories,action.payload],isLoaded: true}
        }
        case CategoryActionTypes.CREATE_CATEGORY_FAIL:{
            return {...categoryState,isLoaded: false}
        }


        case CategoryActionTypes.FETCH_CATEGORIES_SUCCESS:{
            return {...categoryState,categories: action.payload,isLoaded:true}
        }

        case CategoryActionTypes.FETCH_CATEGORIES_FAIL:{
            return {...categoryState,error:action.payload,isLoaded:false}
        }

        default:return categoryState;
    }
}
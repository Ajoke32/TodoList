import {Epic, ofType} from "redux-observable";
import {catchError, filter, from, map, mergeMap, of} from "rxjs";
import {todoClient} from "../../apollo";
import omitDeep from "omit-deep-lodash";
import {Category, CategoryAction, CategoryActionTypes} from "../../types/category";
import {getAllGategoriesQuery} from "../../graphQL/query/category";
import {
    createCategory,
    createCategoryFail,
    createCategorySuccess,
    fetchCategoryFail,
    fetchCategorySuccess
} from "../action-creators/category";
import {ApolloError} from "@apollo/client";
import {createCategoryMutation} from "../../graphQL/mutations/category";
import {isOfType} from "typesafe-actions";

interface CategoryResponse{
    category:{
        categories:Category[]
    }
}
interface CategoryCreateResponse{
    category:{
        createCategory:Category
    }
}
export const fetchCategoryEpic: Epic<CategoryAction> = (action$) => action$.pipe(
    ofType(CategoryActionTypes.FETCH_CATEGORIES),
    mergeMap(action =>
        from(
            todoClient.query<CategoryResponse>(
                {
                    query:getAllGategoriesQuery,
                    fetchPolicy:"no-cache"
                }
            )).pipe(
            map(response => {
                const res = omitDeep(response.data.category.categories,'__typename') as Category[];
                return fetchCategorySuccess(res);
            }),
            catchError((e:ApolloError)=>of(e).pipe(
                map(e=>fetchCategoryFail("fetching error"))
            ))
        ))
);
export const createCategoryEpic:Epic<CategoryAction> = (action$)=>action$.pipe(
    filter(isOfType(CategoryActionTypes.CREATE_CATEGORY)),
    mergeMap(action=>{
        return from(
            todoClient.mutate<CategoryCreateResponse>(
                {
                    mutation:createCategoryMutation,
                    variables: {
                        title:action.payload
                    }
                }
            )).pipe(
               map(res=>{
                   if(res.data){
                       const cat:Category = omitDeep(res.data.category.createCategory,'__typename') as Category;
                       return createCategorySuccess(cat);
                   }
                   return createCategoryFail("create fail");
               }),
              catchError(e=>of(e).pipe(
                 map(e=>createCategoryFail("server or graphql error"))
              ))
            )
    })
)
import {combineReducers} from "redux";
import {todoReducer} from "./todoReducer";
import {categoryReducer} from "./categoryReducer";


export const rootReducer = combineReducers({
    todos:todoReducer,
    categories:categoryReducer
});

export type RootState = ReturnType<typeof rootReducer>;

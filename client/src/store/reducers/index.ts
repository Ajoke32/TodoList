import { combineReducers} from "redux";
import {todoReducer} from "./todoReducer";
import {categoryReducer} from "./categoryReducer";
import {combineEpics} from "redux-observable";
import * as t from "../epics/todo"
import * as c from "../epics/category";




export const rootReducer = combineReducers({
    todos:todoReducer,
    categories:categoryReducer
});

export const rootEpic = combineEpics<any>(
    ...Object.values(t),
    ...Object.values(c)
)


export type RootState = ReturnType<typeof rootReducer>;

import {combineReducers} from "redux";
import {todoReducer} from "./todoReducer";
import {categoryReducer} from "./categoryReducer";
import {combineEpics, Epic} from "redux-observable";
import {deleteTodoEpic, fetchTodosEpic, updateTodoEpic} from "../epics/todo"


export const rootReducer = combineReducers({
    todos:todoReducer,
    categories:categoryReducer
});

export const rootEpic = combineEpics(
    fetchTodosEpic
    ,updateTodoEpic,
    deleteTodoEpic
)


export type RootState = ReturnType<typeof rootReducer>;

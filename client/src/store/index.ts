import {applyMiddleware, createStore} from "redux";
import {rootEpic, rootReducer} from "./reducers";
import {createEpicMiddleware, EpicMiddleware} from 'redux-observable';
import {TodoAction} from "../types/todo";

const epicMiddleware:EpicMiddleware<TodoAction> = createEpicMiddleware<TodoAction>();

export const store = createStore(rootReducer,applyMiddleware(epicMiddleware));

epicMiddleware.run(rootEpic)
export const AppDispatch = store.dispatch;
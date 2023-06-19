import { AiOutlineDelete,AiOutlineCheck,AiOutlineUndo } from "react-icons/ai";
import {useTypedSelector} from "../hooks/useTypedSelector";
import {Todo} from "../types/todo";
import {AiOutlineFieldTime} from "react-icons/ai";
import {AppDispatch} from "../store";
import {removeTodo, updateTodo} from "../store/action-creators/todo";
import moment from "moment";

const TodoItem = (props:Todo) => {

    const state = useTypedSelector(state => state);
    const todos = state.todos.todos;
    const dispatch = AppDispatch;


    function onDeleteClick(id:number){
        dispatch(removeTodo(id));
    }

    function toComplete(id:number){
        const todo = todos.filter(t=>t.id===id)[0];
        const updatedTodo = {...todo, isCompleted: !todo.isCompleted};
        dispatch(updateTodo(updatedTodo));
    }

    return (
        <div className={`todo-item ${props.isCompleted ? 'completed' : ''}`}>
            <div className={"text-lg"}>{props.title}</div>
            <div className={"text-lg"} style={{color:"#a3cef1"}} >{props.category!=null?props.category.title:props.categoryId}</div>
            <div className={"text-lg"}>{props.expirationDate==null?<AiOutlineFieldTime />:moment(props.expirationDate).format("MM/DD/YY, hh:mm")}</div>
            <div  id="delete" className="clickable" onClick={()=>onDeleteClick(props.id)}><AiOutlineDelete /></div>
            {props.isCompleted?<div className="clickable" id="undo-complete" onClick={()=>toComplete(props.id)}> <AiOutlineUndo /> </div>:
                <div className="clickable" id="complete" onClick={()=>toComplete(props.id)}><AiOutlineCheck /></div >}
        </div>
    );
};

export default TodoItem;

import { AiOutlineDelete,AiOutlineCheck,AiOutlineUndo } from "react-icons/ai";
import {useTypedSelector} from "../hooks/useTypedSelector";
import {Todo} from "../types/todo";
import {AiOutlineFieldTime} from "react-icons/ai";
import {AppDispatch} from "../store";
import {removeTodo, updateTodo} from "../store/action-creators/todo";

const TodoItem = (props:Todo) => {

    const {todos} = useTypedSelector(state => state.todos);

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
            <div >{props.title}</div>
            <div >{props.categoryName}</div>
            <div>{props.expirationDate==null?<AiOutlineFieldTime />:props.expirationDate.toString()}</div>
            <div id="delete" className="clickable" onClick={()=>onDeleteClick(props.id)}><AiOutlineDelete /></div>
            {props.isCompleted?<div className="clickable" id="undo-complete" onClick={()=>toComplete(props.id)}> <AiOutlineUndo /> </div>:
                <div className="clickable" id="complete" onClick={()=>toComplete(props.id)}><AiOutlineCheck /></div >}
        </div>
    );
};

export default TodoItem;

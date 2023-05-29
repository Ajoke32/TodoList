import { AiOutlineDelete,AiOutlineCheck,AiOutlineUndo } from "react-icons/ai";
import {useActions} from "../hooks/useActions";
import {useTypedSelector} from "../hooks/useTypedSelector";
import {Todo} from "../types/todo";

const TodoItem = (props:Todo) => {

    const {todos} = useTypedSelector(state => state.todos);

    const {removeTodo,updateTodo} = useActions();

    function onDeleteClick(id:number){
        removeTodo(id);
    }
    function toComplete(id:number){
        const todo = todos.filter(t=>t.id===id)[0];
        todo.isCompleted = !todo.isCompleted;
        updateTodo(todo);
    }

    return (
        <div className={`todo-item ${props.isCompleted ? 'completed' : ''}`}>
            <div>{props.id}</div>
            <div>{props.title}</div>
            <div>{props.categoryName}</div>
            <div>{props.expirationDate==null?"":props.expirationDate.toString()}</div>
            <div>{props.isCompleted?"yes":"no"}</div>
            <div id="delete" onClick={()=>onDeleteClick(props.id)}><AiOutlineDelete /></div>
            {props.isCompleted?<div id="undo-complete" onClick={()=>toComplete(props.id)}> <AiOutlineUndo /> </div>:
                <div id="complete" onClick={()=>toComplete(props.id)}><AiOutlineCheck /></div >}
        </div>
    );
};

export default TodoItem;

import React, {useState} from 'react';
import {useActions} from "../hooks/useActions";
import {Todo} from "../types/todo";
import CategoryList from "./CategoryList";
import {useTypedSelector} from "../hooks/useTypedSelector";


const TodoInputInitialState:Todo = {
    id:0,
    categoryName:"Other",
    title:"",
    expirationDate:null,
    isCompleted:false,
}

const TodoInput = () => {

    const [todo,setTodo] = useState<Todo>(TodoInputInitialState);

    const categories = useTypedSelector(state => state.categories.categories);

    const [save,setSave] = useState(false);

    const [idCount,setIdCount] = useState(0);

    const {createTodo,createCategory} = useActions();

    function onFieldChanged(e:React.ChangeEvent<HTMLInputElement>) {
        const value: typeof todo[keyof typeof todo] = e.target.value;
        setTodo({ ...todo, [e.target.id]: value});
    }

    function onCheckBoxClick(){
        setSave(!save);
    }
    function onFormSubmit(e:React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        setIdCount((prevState)=>++prevState);
        createTodo({...todo,id:idCount});
        if(save&&!categories.find(c=>c.name===todo.categoryName)){
            createCategory({id:0,name:todo.categoryName});
            setSave(!save);
        }
        e.currentTarget.reset();
    }


    return (
        <div>
            <form action="" id="todo-create" onSubmit={onFormSubmit}>
                <input type="text" id="title" placeholder="Title" name="title" onChange={onFieldChanged} required />
                <CategoryList onChange={onFieldChanged} />
                <input type="datetime-local" id="expirationDate" name="expirationDate" onChange={onFieldChanged}/>
                <label className="try" htmlFor="save"><input onClick={onCheckBoxClick} type="checkbox" id="save" name="save" /> Save category</label>
                <input type="submit" value="send"/>
            </form>
        </div>
    );
};

export default TodoInput;

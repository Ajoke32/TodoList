import React, {useEffect, useState} from 'react';
import {Todo} from "../types/todo";
import CategoryList from "./CategoryList";
import {useTypedSelector} from "../hooks/useTypedSelector";
import {AppDispatch} from "../store";
import {createTodo} from "../store/action-creators/todo";
import {createCategory} from "../store/action-creators/category";





const TodoInputInitialState: Todo = {
    id: 0,
    categoryId: 7,
    title: "",
    expirationDate: null,
    isCompleted: false
}

const TodoInput = () => {

    const [todo, setTodo] = useState<Todo>(TodoInputInitialState);

    const [category,setCategory] = useState<string|number>(7)

    const categoryState = useTypedSelector(state => state.categories);

    const [buttonStyle,setStyle] = useState<string>("display-none")
    const [disable,setDisable] = useState<boolean>(false);

    const dispatch = AppDispatch;

    useEffect(() => {
        if (categoryState.isLoaded) {
            setDisable(false);
            setStyle("display-none");
        }
    }, [categoryState.isLoaded]);

    function onFieldChanged(e: React.ChangeEvent<HTMLInputElement>) {
        const value: typeof todo[keyof typeof todo] = e.target.value;
        setTodo({...todo, [e.target.id]: value});
    }

    function onCategoryFieldChanged(e: React.ChangeEvent<HTMLInputElement>){
        if(parseInt(e.target.value)){
            setCategory(Number(e.target.value));
            setStyle("display-none");
            setDisable(false);
        }else {
            setCategory(e.target.value);
            setStyle("display");
            setDisable(true);
        }
    }

    function saveCategory(){
        dispatch(createCategory(category as string));
    }

    function onFormSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        const searchCategory = categoryState.categories.find(c=>c.title===category);
        if(searchCategory){
            dispatch(createTodo({...todo,categoryId:searchCategory.id}));
        }else{
            dispatch(createTodo({...todo,categoryId:Number(category)}));
        }
        setTodo(TodoInputInitialState);
        setCategory(7);
        e.currentTarget.reset();
    }


    return (
        <div>
            <form action="" id="todo-create" onSubmit={onFormSubmit}>
                    <input type="text" maxLength={15} id="title" placeholder="Title" name="title" onChange={onFieldChanged} required/>
                    <CategoryList onChange={onCategoryFieldChanged}/>
                    <input type="datetime-local" id="expirationDate" name="expirationDate" onChange={onFieldChanged} />
                <input type="submit" disabled={disable} value="add"/>
                <button  type="button" onClick={saveCategory} className={buttonStyle}>save category</button>
            </form>
        </div>
    );
};

export default TodoInput;

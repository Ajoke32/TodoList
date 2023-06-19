import React, {useEffect} from 'react';
import {useTypedSelector} from "../hooks/useTypedSelector";
import {AppDispatch} from "../store";
import {fetchCategory} from "../store/action-creators/category";


interface CategoryListProps{
    onChange:React.ChangeEventHandler<HTMLInputElement>
}

const CategoryList = (props:CategoryListProps) => {

    const categoryState = useTypedSelector(state => state.categories);

    const dispatch = AppDispatch;
    function onDataListInputClick(e:React.MouseEvent<HTMLInputElement>){
        e.currentTarget.value = "";
    }

    useEffect(()=>{
        dispatch(fetchCategory());
    },[]);


    return (
        <>
            <input list="category-list" placeholder="Category" autoComplete={"off"} onClick={onDataListInputClick} id="category-title" name="title" onChange={props.onChange} />
            <datalist id="category-list">
                {categoryState.categories.map((c,index)=>{
                    return <option key={index} value={c.id}>{c.title}</option>
                })}
            </datalist>
        </>
    );
};

export default CategoryList;

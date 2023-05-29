import React from 'react';
import {useTypedSelector} from "../hooks/useTypedSelector";


interface CategoryListProps{
    onChange:React.ChangeEventHandler<HTMLInputElement>
}

const CategoryList = (props:CategoryListProps) => {

    const categoryState = useTypedSelector(state => state.categories);

    function onDataListInputClick(e:React.MouseEvent<HTMLInputElement>){
        e.currentTarget.value = "";
    }

    return (
        <>
            <input list="category-list" placeholder="Category" autoComplete={"off"} onClick={onDataListInputClick} id="categoryName" name="categoryName" onChange={props.onChange} />
            <datalist id="category-list">
                {categoryState.categories.map((c,index)=>{
                    return <option key={index} value={c.name}>{c.name}</option>
                })}
            </datalist>
        </>
    );
};

export default CategoryList;

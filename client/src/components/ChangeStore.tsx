import React, {useState} from 'react';
import {AppDispatch} from "../store";
import {fetchTodo} from "../store/action-creators/todo";
import Switch from "react-switch";
import {fetchCategory} from "../store/action-creators/category";



const ChangeStore = () => {

    const dispatch = AppDispatch;

    const [checked,setChecked] = useState<boolean>(false);


    function handleChange(){
        setChecked(!checked);
        fetch("http://localhost:5266/graphql",{
            method:"POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body:JSON.stringify({query:'mutation{todo{changeStore}}'})
        }).then((res)=>{
            dispatch(fetchTodo());
            dispatch(fetchCategory());
        });
    }

    return (
        <div style={{display:"flex",justifyContent:"flex-end",alignItems:"center",padding:"15px",gap:"5px"}}>
            Db<Switch checked={checked} uncheckedIcon={false} checkedIcon={false} offColor={"#4a4e69"} onColor={"#4a4e69"} onChange={handleChange} />Xml
        </div>
    );
};

export default ChangeStore;

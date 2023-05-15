// eslint-disable-next-line @typescript-eslint/no-unused-vars
import React, {ChangeEvent} from "react";

interface NoteInputProps{
    addNote(note:string):void;
}
export const NoteInput:React.FC<NoteInputProps> = ({addNote})=>{
    const [note,setNote] = React.useState("");

    const updateNote = (event:React.ChangeEvent<HTMLInputElement>):void =>{
        setNote(event.target.value);
    }
    const onAddNoteClick = ()=>{
        addNote(note);
        setNote("");
    }

    return(
      <div>
          <input type="text" name="note" onChange={updateNote} placeholder="Note"/>
          <button onClick={onAddNoteClick}>Add</button>
      </div>
    );
}

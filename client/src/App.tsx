import React from 'react';
import { NoteInput } from './NoteInput';
import {useDispatch, useSelector} from "react-redux";
import {NotesState} from './notesReducer'
import {addNote} from "./actions";

function App() {
    const notes = useSelector<NotesState,NotesState['notes']>((state)=>state.notes);
    const dispatch = useDispatch();

    const onAddNote = (note:string)=>{
        dispatch(addNote(note));
    }

    return (
    <div>
      <NoteInput addNote={onAddNote} />
        <hr/>
        <ul>
            {notes.map((note)=>{
                return <li key={note}>{note}</li>
            })}
        </ul>
    </div>
  );
}

export default App;

import "./item-add.css"
import {useState} from "react";
const ItemAdd = ({onAdded}) => {
    const [text, setText] = useState()

    const onTextChanged=(e)=>{
        setText(e.target.value)
    }
    const onSubmit = (e)=>{
        e.preventDefault()
        if(text.trim()){
            onAdded(text);
            setText('')
        }
    }
    return(
        <form className={"d-flex item-add"} onSubmit={onSubmit}>
            <input
            type={"text"}
            className={"form-control"}
            onChange={onTextChanged}
            value={text}/>
            <button
                className={"btn btn-outline-secondary"}>
                Add Item
            </button>
        </form>


    )
}
export default ItemAdd
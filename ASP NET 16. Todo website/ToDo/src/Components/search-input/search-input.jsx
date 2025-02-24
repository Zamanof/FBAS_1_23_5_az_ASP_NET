import './search-input.css'
import {useState} from "react";
const  SearchInput = ({placeText, onSearchChange})=>{
    const [searchText, setSearchText] = useState("")

    const handleSearchChange = (e)=>{
        const text = e.target.value;
        setSearchText(text);
        onSearchChange(text);
    }

    return(
        <input className={"form-control search-input"}
        type="text"
        placeholder= {placeText}
        onChange={handleSearchChange}
        value={searchText}/>
    )
}
export default SearchInput;
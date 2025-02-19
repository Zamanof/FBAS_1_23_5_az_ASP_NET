import AppHeader from "../app-header/app-header.jsx";
import SearchInput from "../search-input/search-input.jsx";
import StatusFilter from "../status-filter/status-filter.jsx";

const TodoPage =()=>{
    return(
        <div className="app-todo">
            <AppHeader/>
            <div className={"top-panel d-flex"}>
                <SearchInput/>
                <StatusFilter text={"All"} active={true}/>
                <StatusFilter text={"Active"}/>
                <StatusFilter text={"Done"}/>

            </div>
        </div>

    )
}
export default TodoPage
import AppHeader from "../app-header/app-header.jsx";
import SearchInput from "../search-input/search-input.jsx";
import StatusFilter from "../status-filter/status-filter.jsx";
import ItemAdd from "../item-add/item-add.jsx";
import TaskList from "../task-list/task-list.jsx";
import TodoService from "../../Services/todo-service.js";
import {useEffect, useState} from "react";


const TodoPage =()=>{
    const service = new TodoService()
    const [tasks, setTasks] = useState([])
    const [searchText, setSearchText] = useState('')

    useEffect(() => {
        updateData()
    }, []);
    const addItem = (text)=>{
        service.AddItem(text)
            .then(()=>{updateData()})
    }

    const updateData = ()=>{
        service.getAll().then((data)=>{
            setTasks(data)
        })
    }

    return(
        <div className="app-todo">
            <AppHeader/>
            <div className={"top-panel d-flex"}>
                <SearchInput/>
                <StatusFilter text={"All"} active={true}/>
                <StatusFilter text={"Active"}/>
                <StatusFilter text={"Done"}/>
            </div>
            <TaskList tasks={tasks} onDeleted={""} onChecked={""}/>
            <ItemAdd onAdded={addItem}/>
        </div>

    )
}
export default TodoPage
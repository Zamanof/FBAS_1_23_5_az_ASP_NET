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

    const onChangeStatus = (id, status)=>{
        console.log(id)
        service.changeStatus(id, status)
    }

    const deleteItem = (id)=>{
        setTasks((tasks)=> tasks.filter((task)=> task.id !== id))
    }

    const onSearchChange=(text)=>{
        setSearchText(text)
    }

    const search = (tasks, searchText) =>{
        if (searchText.length === 0) return tasks;
        return tasks.filter((task)=>
            task.text.toLowerCase().includes(searchText.toLowerCase()))
    }

    const filteredTasks = search(tasks, searchText)

    return(
        <div className="app-todo">
            <AppHeader/>
            <div className={"top-panel d-flex"}>
                <SearchInput placeText={"Search..."} onSearchChange={onSearchChange}/>
                <StatusFilter text={"All"} active={true}/>
                <StatusFilter text={"Active"}/>
                <StatusFilter text={"Done"}/>
            </div>
            <TaskList tasks={filteredTasks}
                      onDeleted={deleteItem}
                      onChecked={onChangeStatus}/>
            <ItemAdd onAdded={addItem}/>
        </div>

    )
}
export default TodoPage
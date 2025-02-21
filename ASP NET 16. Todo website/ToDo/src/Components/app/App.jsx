import './App.css'
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import HomePage from "../home-page/home-page.jsx";
import RegisterForm from "../register-form/register-form.jsx";
import TodoPage from "../todo-page/todo-page.jsx";
import LoginForm from "../login-form/login-form.jsx";
function App() {
    return (
        <BrowserRouter>
            <Routes >
                <Route index element={<HomePage/>}/>
                <Route path="register" element={<RegisterForm/>}/>
                <Route path="login" element={<LoginForm/>}/>
                <Route path="todo" element={<TodoPage/>}/>

            </Routes>
        </BrowserRouter>
    )

}

export default App

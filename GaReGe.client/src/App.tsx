import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import HomePage from "./components/home/HomePage.tsx";
import NavBarComponent from "./components/nav/NavBarComponent.tsx";
import MembersPage from "./components/member/MembersPage.tsx";

function App() {
    return (
        <BrowserRouter>
              
                <NavBarComponent/>

            <div className='container mt-5 '>
                <Routes>

                    
                    <Route path={"/"} element={<HomePage/>}/>
                    <Route path={"/members"} element={<MembersPage/>}/>


                </Routes>


            </div>
        </BrowserRouter>
    );
}

export default App;

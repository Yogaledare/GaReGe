import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import MembersTable from "./components/member/MembersTable.tsx";
import HomePage from "./components/home/HomePage.tsx";

function App() {
    return (
        <BrowserRouter>
            <div className='container mt-5 '>
              

                <Routes>

                    
                    <Route path={"/"} element={<HomePage/>}/>
                    <Route path={"/members"} element={<MembersTable/>}/>


                </Routes>


            </div>
        </BrowserRouter>
    );
}

export default App;

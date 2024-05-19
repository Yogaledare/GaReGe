import {Link} from "react-router-dom";

const NavBarComponent = () => {


    return (
        <>
            <nav className={"navbar navbar-expand navbar-dark bg-dark"}>
                <div className={"container-fluid"}>
                    <Link className={"navbar-brand"} to={"/"}>GaReGe</Link>
                    <div className={"navbar-collapse"}>
                        <ul className={"navbar-nav"}>
                            <li className={"nav-item"}>
                                <Link className={"nav-link"} to={"/"}>Home</Link>
                            </li>
                            <li className={"nav-item"}>
                                <Link className={"nav-link"} to={"/members"}>Members</Link>
                            </li>
                            <li className={"nav-item"}>
                                <Link className={"nav-link"} to={"/vehicles"}>Vehicles</Link>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </>
    )
}


export default NavBarComponent; 
import {Link} from "react-router-dom";
import {useFetchVehicles} from "../../hooks/vehiclesHooks.ts";
import ApiStatus from "../api/ApiStatus.tsx";
import {useNavigate} from "react-router";


const MembersPage = () => {

    const nav = useNavigate(); 
    const {data: vehicles, status, isSuccess} = useFetchVehicles();

    if (!isSuccess) {
        return (<ApiStatus status={status}/>)
    }

    return (
        <>
            <h1 className={"mb-4"}>Vehicles</h1>
            {/*<Link className={"btn btn-primary mb-4"} to={"/members/create"}>Register new member</Link>*/}

            <table
                className={"table table-hover hover-pointer"}>
                <thead>
                <tr>
                    <th>ID</th>
                    <th>License Plate</th>
                    <th>Type</th>
                    <th>Brand</th>
                    <th>Model</th>
                    <th>Owner</th>
                </tr>
                </thead>

                <tbody>
                {vehicles && vehicles.map(vehicle => (
                    <tr
                        key={vehicle.vehicleId}
                        onClick={() => nav(`/vehicles/${vehicle.vehicleId}`)}
                    >
                        <td>{vehicle.vehicleId}</td>
                        <td>{vehicle.licensePlate}</td>
                        <td>{vehicle.vehicleTypeName}</td>
                        <td>{vehicle.brand}</td>
                        <td>{vehicle.model}</td>
                        <td>{vehicle.memberName}</td>
                    </tr>
                ))}


                </tbody>


            </table>


        </>
    );
}


export default MembersPage; 
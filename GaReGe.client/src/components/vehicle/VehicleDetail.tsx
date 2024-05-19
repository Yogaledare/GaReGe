import {useFetchVehicleDetail, useFetchVehicles} from "../../hooks/vehiclesHooks.ts";
import {useParams} from "react-router";
import ApiStatus from "../api/ApiStatus.tsx";
import {Link} from "react-router-dom";


const VehicleDetail = () => {
    const {id} = useParams();
    if (!id) throw Error("No vehicle id provided");
    const memberId = parseInt(id);

    const {data: vehicle, status, isSuccess} = useFetchVehicleDetail(memberId);

    if (!isSuccess || !vehicle) {
        return (<ApiStatus status={status}/>)
    }

    return (
        <>
            <h1 className={"mb-4"}>{`${vehicle.licensePlate}`}</h1>
            <div className={"d-flex"}></div>
            {/*<Link*/}
            {/*    to={`/members/${member.memberId}/update`}*/}
            {/*    className={"btn btn-primary"}*/}

            {/*>*/}
            {/*    Edit*/}
            {/*</Link>*/}
            {/*<button*/}
            {/*    onClick={() => deleteMemberMutation.mutate(member)}*/}
            {/*    className={"btn btn-danger ms-2"}*/}
            {/*>*/}
            {/*    Delete*/}
            {/*</button>*/}
            <div className="row mt-3">

                <div className="col-8">


                        <table
                            className={"table table-bordered"}
                        >
                            <tbody>
                            <tr>
                                <th>Vehicle ID</th>
                                <td>{vehicle.vehicleId}</td>
                            </tr>
                            <tr>
                                <th>Color</th>
                                <td>{vehicle.color}</td>
                            </tr>
                            <tr>
                                <th>brand</th>
                                <td>{vehicle.brand}</td>
                            </tr>
                            <tr>
                                <th>model</th>
                                <td>{vehicle.model}</td>
                            </tr>
                            <tr>
                                <th>numWheels</th>
                                <td>{vehicle.numWheels}</td>
                            </tr>
                            <tr>
                                <th>vehicleTypeId</th>
                                <td>{vehicle.vehicleTypeId}</td>
                            </tr>
                            <tr>
                                <th>memberId</th>
                                <td>{vehicle.memberId}</td>
                            </tr>
                            <tr>
                                <th>vehicleTypeName</th>
                                <td>{vehicle.vehicleTypeName}</td>
                            </tr>
                            <tr>
                                <th>memberName</th>
                                <td>{vehicle.memberName}</td>
                            </tr>
                            </tbody>
                        </table>

                    
                    {/*<div className="card">*/}
                    {/*    <div className="card-body">*/}
                    {/*        <h5*/}
                    {/*            className={"card-title mb-3"}*/}
                    {/*        >Vehicle information</h5>*/}
                    {/*        <div className="row">*/}
                    {/*            <div className="col-8">*/}
                    {/*                <p>Vehicle ID:</p>*/}
                    {/*            </div>*/}
                    {/*            <div className="col">*/}
                    {/*                {vehicle.vehicleId}*/}
                    {/*            </div>*/}
                    
                    
                    {/*        </div>*/}
                    {/*        <p className={"card-text"}>Vehicle ID: {vehicle.vehicleId}</p>*/}
                    {/*        <p className={"card-text"}>Color: {vehicle.color}</p>*/}
                    {/*        <p className={"card-text"}>brand: {vehicle.brand}</p>*/}
                    {/*        <p className={"card-text"}>model: {vehicle.model}</p>*/}
                    {/*        <p className={"card-text"}>numWheels: {vehicle.numWheels}</p>*/}
                    {/*        <p className={"card-text"}>vehicleTypeId: {vehicle.vehicleTypeId}</p>*/}
                    {/*        <p className={"card-text"}>vehicleTypeName: {vehicle.vehicleTypeName}</p>*/}
                    {/*        <h5*/}
                    {/*            className={"card-title"}*/}
                    {/*        >Owner information</h5>*/}
                    {/*        <p className={"card-text"}>memberName: {vehicle.memberName}</p>*/}
                    
                    
                    {/*    </div>*/}
                    
                    {/*</div>*/}
                </div>


                {/*<div className="col-6">*/}
                {/*    <img className="img-fluid" src={member.avatar} alt="Portrait"/>*/}
                {/*</div>*/}

                {/*<div className="row mt-3">*/}
                {/*    <div className="col">*/}
                {/*        {member.description}*/}
                {/*    </div>*/}
                {/*</div>*/}
            </div>
        </>
    )

}

export default VehicleDetail;


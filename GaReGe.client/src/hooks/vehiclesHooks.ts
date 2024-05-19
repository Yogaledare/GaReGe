import {useQuery} from "react-query";
import axios, {AxiosError} from "axios";
import {VehicleDetail, VehicleSummary} from "../types/vehicle.ts";
import config from "../config.ts";


const useFetchVehicles = () => {
    return useQuery<VehicleSummary[], AxiosError>(['vehicles'], async () => {
        const response = await axios.get(`${config.baseApiUrl}/vehicles`);
        return response.data;
    })
}

const useFetchVehicleDetail = (vehicleId: number) => {
    return useQuery<VehicleDetail, AxiosError>(['vehicle', vehicleId], async () => {
        const response = await axios.get(`${config.baseApiUrl}/vehicles/${vehicleId}`);
        return response.data;
    })
}




export {useFetchVehicles, useFetchVehicleDetail}


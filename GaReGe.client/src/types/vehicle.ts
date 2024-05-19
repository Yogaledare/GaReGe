export type VehicleSummary = {
    vehicleId: number,
    licensePlate: string;
    brand: string;
    model: string;
    vehicleTypeName: string;
    memberName: string;
}


export type VehicleDetail = {
    vehicleId: number; 
    licensePlate: string;
    color: string;
    brand: string;
    model: string;
    numWheels: number;
    memberId: number;
    vehicleTypeId: number;
    vehicleTypeName: string;
    memberName: string;
}


// export type Vehicle = {
//     vehicleId?: number;
//     licensePlate: string;
//     color: string;
//     brand: string;
//     model: string;
//     numWheels: number;
//     memberId: number;
//     vehicleTypeId: number;
//     vehicleTypeName: string;
//     memberName: string;
// }
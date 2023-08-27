export interface Project {
    id: number;
    name: string;
    customerName: string;
    userName: string;
    status: number;
    projectStartDate: Date;
    projectEndDate: Date;
    tasks: number
}
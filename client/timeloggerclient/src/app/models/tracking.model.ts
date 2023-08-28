export interface Tracking {
    id: number;
    projectName: string,
    taskCode: string,
    default: boolean,
    hourlyRate: number,
    overtimeRate: number,
    note: string;
    date: string;
    status: number;
    projectStartDate: Date;
    projectEndDate: Date;
    duration: number;
}
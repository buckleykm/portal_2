import { App } from './app';

export interface User {
    id: number;
    brokerTempId: number;
    username: string;
    fstname: string;
    lstname: string;
    branch: string;
    address: string;
    city: string;
    state: string;
    ZipCode: number;
    email: string;
    phone: number;
    isContracted: boolean;
    modifyWhen: Date;
    lastActive: Date;
    phoneExt?: number;
    AltPhone?: number;
    altEmail?: string;
    rbm?: string;
    affiliate?: string;
    npnId?: number;
    entityId: number;
    apps?: App[];

}

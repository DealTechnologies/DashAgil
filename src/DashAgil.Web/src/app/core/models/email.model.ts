import * as moment from 'moment';
import { EmailStatus } from '../enums/emailStatus.enum';

export class Email {
    id: string;
    assunto: string;
    conteudo: string;
    remetente: string;
    destinatario: string;
    dataCriacao: string;
    dataEnvio: string;
    entregues: string;
    lixo: string;
    rejeitados: string;
    abertos: string;
    status: string;

    constructor(email: any) {
        this.id = email.id;
        this.assunto = email.assunto;
        this.conteudo = email.conteudo;
        this.remetente = email.remetente;
        this.destinatario = email.destinatario !== undefined ? JSON.parse(email.destinatario).join(', ') : email.destinatario;
        this.dataCriacao = email.dataCriacao !== null ? moment(email.dataCriacao).format("DD/MM/YYYY hh:mm:ss") : email.dataCriacao;
        this.dataEnvio = email.dataEnvio ? moment(email.dataEnvio).format("DD/MM/YYYY hh:mm:ss") : email.dataEnvio;
        this.entregues = email.entregues !== null ? JSON.parse(email.entregues).map(o => o.deliveryDate + ' - ' + JSON.parse(o.recipient)).join(', ') : email.entregues;
        this.lixo = email.lixo;
        this.rejeitados = email.rejeitados;
        this.abertos = email.abertos;
        this.status = EmailStatus[email.status];
    }
}

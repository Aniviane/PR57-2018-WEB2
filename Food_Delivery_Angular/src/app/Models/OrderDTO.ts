import { OrderItemDTO } from "./OrderItemDTO";

export class OrderDTO {
    // public long Id { get; set; }
    // public long OrdererId { get; set; }

    // public long? DeliveryId { get; set; }

    // public long RestorauntId { get; set; }

    // public DateTime TimeOfOrder { get; set; }

    // public string Comment { get; set; }

    // public List<OrderItemDTO> OrderItems { get; set;}

    id:number;
    ordererId:number;
    deliveryId:number;
    restorauntId:number;
    timeOfOrder:Date;
    comment: string;
    orderItems: OrderItemDTO[];
    status : string;

    constructor(comment:string, ordererid:number, OrderItems: OrderItemDTO[], restId:number, status:string) {
        this.id = 0;
        this.ordererId = ordererid;
        this.deliveryId = -1;
        this.restorauntId= restId;
        this.timeOfOrder = new Date();
        this.comment = comment;
        this.orderItems = OrderItems;
        this.status = status;
    }
}
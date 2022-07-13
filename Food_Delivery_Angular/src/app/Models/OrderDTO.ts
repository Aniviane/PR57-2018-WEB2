import { OrderItemDTO } from "./OrderItemDTO";

export class OrderDTO {
    // public long Id { get; set; }
    // public long OrdererId { get; set; }

    // public long? DeliveryId { get; set; }

    // public long RestorauntId { get; set; }

    // public DateTime TimeOfOrder { get; set; }

    // public string Comment { get; set; }

    // public List<OrderItemDTO> OrderItems { get; set;}

    Id:number;
    OrdererId:number;
    DeliveryId:number;
    RestaurantId:number;
    TimeOfOrder:Date;
    Comment: string;
    OrderItems: OrderItemDTO[];
    constructor(comment:string, ordererid:number, OrderItems: OrderItemDTO[], restId:number) {
        this.Id = 0;
        this.OrdererId = ordererid;
        this.DeliveryId = -1;
        this.RestaurantId = restId;
        this.TimeOfOrder = new Date();
        this.Comment = comment;
        this.OrderItems = OrderItems;
    }
}
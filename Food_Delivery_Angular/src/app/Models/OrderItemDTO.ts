export class OrderItemDTO {
    // public long Id { get; set; }
    //     public long DishId { get; set; }
    //     public long OrderId { get; set; }

    //     public string DishComment { get; set; }

    id : number;
    dishId : number;
    orderId : number;
    dishComment : string;

    constructor(dish:number,comment:string) {
        this.id = 0;
        this.dishId = dish;
        this.orderId = 0;
        this.dishComment = comment;
    }
}
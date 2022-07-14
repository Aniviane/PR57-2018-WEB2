import { DishDTO } from "./DishDTO";

export class RestaurantDTO {
    // public long Id { get; set; }
    //     public string RestName { get; set; }

    //     public int Stars { get; set; }

    //     public List<DishDTO> Dishes { get; set; }


    id : number;
    restName : string;
    stars : number;
    dishes : DishDTO[];

    constructor() {
        this.id = 0;
        this.stars = 0;
        this.restName = "";
        this.dishes = [];
    }

}
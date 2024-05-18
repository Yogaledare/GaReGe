const HomePage = () => {


    return (

        <>
            <h1 className={"mb-3"}>Welcome to GaReGe!</h1>
            <div id="carouselExampleSlidesOnly" className="carousel slide" data-ride="carousel">
                <div className="carousel-inner">
                    <div className="carousel-item active">
                        <img className="d-block w-100" src="https://picsum.photos/800/400" alt="First slide"/>
                    </div>
                    <div className="carousel-item">
                        <img className="d-block w-100" src="https://picsum.photos/800/400" alt="Second slide"/>
                    </div>
                    <div className="carousel-item">
                        <img className="d-block w-100" src="https://picsum.photos/800/400" alt="Third slide"/>
                    </div>
                </div>
            </div>
            <div className={"my-3"}>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Autem corporis debitis delectus
                    dignissimos
                    eos fuga fugit illo illum, ipsam iusto laboriosam magnam nam necessitatibus obcaecati porro
                    possimus
                    vel veritatis! Quam. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Magni mollitia
                    nisi reprehenderit vitae? Aliquam asperiores atque consequatur, corporis est explicabo fugit
                    inventore magnam magni nesciunt, obcaecati perferendis reiciendis sequi. Facilis.</p>
            </div>

        </>


    )
}

export default HomePage; 
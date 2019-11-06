import React, { Component } from 'react';
import './Navbar.css';

export class Navbar extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            addMeal: false,
            insertInventory: false,
            removeInventory: false,
        };
    }

    selectAddMeal = () => {
        this.setState({ addMeal: true, insertInventory: false, removeInventory: false });
    }

    selectInsertToInventory = () => {
        this.setState({ addMeal: false, insertInventory: true, removeInventory: false });
    }

    selectRemoveFromInventory = () => {
        this.setState({ addMeal: false, insertInventory: false, removeInventory: true });
    }

    render() {
        const component =  null;
        if (this.state.addMeal){}
            //component = (<AddMeal/>);
        if (this.state.insertInventory){}
            //component = (<InsertInventory/>);
        if (this.state.removeInventory){}
            //component = (<RemoveInventory/>);
        return (
            <>
                <h4>Select Option</h4>
                <div class="navbar">
                    <button onClick={this.selectAddMeal}>Add Meal</button>
                    <button onClick={this.selectInsertToInventory}>Insert into Inventory</button>
                    <button onClick={this.selectRemoveFromInventory}>Remove from Inventory</button>
                </div>
            </>
            
        );
    }
}
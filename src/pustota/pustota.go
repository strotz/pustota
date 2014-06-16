package main

import (
	"fmt"
	"pustota/dirty"
)

func main() {
	if err := dirty.GoFixVersion(); err != nil {
		fmt.Println(err.Error())
	}
}

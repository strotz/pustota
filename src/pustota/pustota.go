package main

import (
	"pustota/dirty"
	"fmt"
)

func main() {
	if err := dirty.GoFixVersion(); err != nil {
		fmt.Println(err.Error())
	}
}

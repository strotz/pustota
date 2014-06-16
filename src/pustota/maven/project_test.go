package maven

import (
	"testing"
	"fmt"
	"encoding/xml"
)

func TestProjectToXml(t *testing.T) {
	v := Project{}

	output, err := xml.NewEncoder().Encode(v)
	if err != nil {
		t.Errorf("error: %v\n", err)
	}

	fmt.Println(output)
}


package dirty

import (
	"github.com/strotz/etree"
)

func GoFixVersion() error {
	doc := etree.NewDocument()

	if err := doc.ReadFromFile("pom.xml"); err != nil {
		return err
	}
	if err := doc.WriteToFile("pom.xml"); err != nil {
		return err
	}

	return nil
}

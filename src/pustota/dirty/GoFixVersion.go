package dirty

import (
	"os"
	"github.com/strotz/etree"
	"bufio"
	"fmt"
	"strings"
)

func GoFixVersion() error {
	doc := etree.NewDocument()

	if err := doc.ReadFromFile("pom.xml"); err != nil {
		return err
	}

	buffer, err := doc.WriteToString()
	if err != nil {
		return err
	}

	out, err := os.Create("pom.xml")
	if err != nil {
		return err
	}
	defer out.Close()

	w := bufio.NewWriter(out)
	var lines []string
	lines = strings.Split(buffer, "\n")
	for _, line := range lines {
		fmt.Fprint(w, line, "\r\n")
	}
	return w.Flush()

	return nil
}
